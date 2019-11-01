﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Custom/Flag" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Speed("Speed", Range(0, 2.0)) = 1
		_Frequency("Frequency", Range(0,1000.0)) = 1
		_Amplitude("Amplitude", Range(0, 1.0)) = 1
		_Unknown("Unknown", Range(-0.02, 0.02)) = 1
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			Cull off

			Pass {

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				sampler2D _MainTex;
				float4 _MainTex_ST;

				struct v2f {
					float4 pos : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				float _Speed;
				float _Frequency;
				float _Amplitude;
				float _Unknown;

				v2f vert(appdata_base v)
				{
					v2f o;
					v.vertex.x += cos((v.vertex.z + _Time.x * _Speed) * _Frequency) * _Amplitude * (v.vertex.z - _Unknown);
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					return tex2D(_MainTex, i.uv);
				}

				ENDCG

			}
		}
			FallBack "Diffuse"

}







