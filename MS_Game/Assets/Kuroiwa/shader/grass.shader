Shader "Grass"
{
	Properties
	{
		//���_�̐F
		_TopColor("Top Color", Color) = (1.0, 1.0, 1.0, 1.0)
		//���{�̐F
		_BottomColor("Bottom Color", Color) = (0.0, 0.0, 0.0, 1.0)
		//VFX�p�̍����̃e�N�X�`��
		_HeightMap("HeightMap", 2D) = "white" {}
		//VFX�p�̕��̃e�N�X�`��
		_WidthMap("WidthMap", 2D) = "white" {}
		//VFX�p�̕��̌����̃e�N�X�`��
		_WindDistortionMap("Wind Distortion Map", 2D) = "white" {}
		//�����̊�l
		_Height("Height", Range(0., 20)) = 10
		//���̊�l
		_Width("Width", Range(0., 5)) = 1
		//�����̔䗦@bottom, middle, high
		_HeightRate("HeightRate", Vector) = (0.3,0.4,0.5,0)
		//���̔䗦@bottom, middle, high
		_WidthRate("WidthRate", Vector) = (0.5,0.4,0.25,0)
		//���̗h�ꗦ@bottom, middle, high
		_WindPowerRate("WidthPowerRate", Vector) = (0.3, 1.0, 2.0, 0)
		//���̋���
		_WindPower("WindPower", Range(0., 10.0)) = 2.0
		//������������
		_WindFrequency("WindFrequency'", Range(0., 0.1)) = 0.05
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma geometry geom

			#include "UnityCG.cginc"

			struct v2g
			{
				float4 pos : SV_POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
				float2 height : TEXCOORD1;
				float2 width : TEXCOORD2;
			};

			struct g2f
			{
				float4 pos : SV_POSITION;
				fixed4 col : COLOR;
			};

			float rand(float3 co)
			{
				return frac(sin(dot(co.xyz, float3(12.9898, 78.233, 53.539))) * 43758.5453);
			}

			sampler2D _HeightMap, _WidthMap,_WindDistortionMap;
			float4 _WindDistortionMap_ST;
			float4 _TopColor, _BottomColor, _HeightRate, _WidthRate, _WindPowerRate;
			float _Height, _Width,_WindPower,_WindFrequency;

			v2g vert(appdata_base v)
			{
				v2g o;
				float4 uv = float4(v.texcoord.xy, 0.0f, 0.0f);
				o.pos = v.vertex;
				o.uv = v.texcoord.xy;
				o.normal = v.normal;

				//VFX
				o.height = tex2Dlod(_HeightMap,uv);
				o.width = tex2Dlod(_WidthMap,uv);
				return o;
			}

			[maxvertexcount(7)]
			void geom(triangle v2g IN[3], inout TriangleStream<g2f> tristream)
			{

				float4 pos0 = IN[0].pos;
				float4 pos1 = IN[1].pos;
				float4 pos2 = IN[2].pos;


				float3 nor0 = IN[0].normal;
				float3 nor1 = IN[1].normal;
				float3 nor2 = IN[2].normal;

				//���͂��ꂽ�O�p���b�V���̒��_���W�̕��ϒl
				float4 centerPos = (pos0 + pos1 + pos2) / 3;
				//�@���x�N�g���̕��ϒl
				float4 centerNor = float4((nor0 + nor1 + nor2).xyz / 3, 1.0f);

				// VFX�p�̍����A���̒���
				float height = (IN[0].height.r + IN[1].height.r + IN[2].height.r) / 3.0f;
				float width = (IN[0].width.r + IN[1].width.r + IN[2].width.r) / 3.0f;

				//���̌���
				float4 dir = float4(normalize(pos2 * rand(pos2) - pos0 * rand(pos1)).xyz * width, 1.0f);

				//�������}�b�s���O�p�̃e�N�X�`��
				//tilitn, offset����������uv���W�{uv�X�N���[��
				//xz���ʂ�uv���W�ɑΉ�
				float2 uv = pos0.xz * _WindDistortionMap_ST.xy + _WindDistortionMap_ST.zw + _WindFrequency * _Time.y;
				//��������RG��񁗃p�[�����m�C�Y
				float2 windDir_xy = (tex2Dlod(_WindDistortionMap, float4(uv, 0, 0)).xy * 2 - 1) * _WindPower;
				float4 wind = float4(windDir_xy, 0,0);

				g2f o[7];

				//bottom
				o[0].pos = centerPos - dir * _Width * _WidthRate.x;
				o[0].col = _BottomColor;

				o[1].pos = centerPos + dir * _Width * _WidthRate.x;
				o[1].col = _BottomColor;

				//bottom2middle
				o[2].pos = centerPos - dir * _Width * _WidthRate.y + centerNor * height * _Height * _HeightRate.x;
				o[2].col = lerp(_BottomColor, _TopColor, 0.33333f);

				o[3].pos = centerPos + dir * _Width * _WidthRate.y + centerNor * height * _Height * _HeightRate.x;
				o[3].col = lerp(_BottomColor, _TopColor, 0.33333f);

				//middley2high
				o[4].pos = o[3].pos - dir * _Width * _WidthRate.z + centerNor * height * _Height * _HeightRate.y;
				o[4].col = lerp(_BottomColor, _TopColor, 0.6666f);

				o[5].pos = o[3].pos + dir * _Width * _WidthRate.z + centerNor * height * _Height * _HeightRate.y;
				o[5].col = lerp(_BottomColor, _TopColor, 0.6666f);

				//top
				o[6].pos = o[5].pos + centerNor * height * _Height * _HeightRate.z;
				o[6].col = _TopColor;

				// wind
				o[2].pos += wind * _WindPowerRate.x;
				o[3].pos += wind * _WindPowerRate.x;
				o[4].pos += wind * _WindPowerRate.y;
				o[5].pos += wind * _WindPowerRate.y;
				o[6].pos += wind * _WindPowerRate.z;

				////uv���W
				//float2 uv0 = IN[0].uv;
				//float2 uv1 = IN[1].uv;
				//float2 uv2 = IN[2].uv;
				//float2 centerUv = (uv2 + uv1 + uv0) / 3.0f;
				//float2 uv = centerUv + _WindDistortionMap_ST.zw + _WindFrequency * _Time.y;

				[unroll]
				for (int i = 0; i < 7; i++) 
				{
					o[i].pos = UnityObjectToClipPos(o[i].pos);
					tristream.Append(o[i]);
				}

			}

			fixed4 frag(g2f i) : SV_Target
			{
			   fixed4 col = i.col;
			   return col;
			}
			 ENDCG
		}
	}
}