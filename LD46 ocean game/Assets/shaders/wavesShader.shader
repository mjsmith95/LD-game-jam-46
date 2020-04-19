Shader "Custom/Waves" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0 
		_Amplitude("Amplitude", Float) = 1 
		_Wavelength("Wavelength", Float) = 10 
		_Speed("Speed", Float) = 1 
		_NoiseTex("Noise Texture", 2D) = "white" {}
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows vertex:vert
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _NoiseTex;
			half _Glossiness;
			half _Metallic;
			fixed4 _Color;
			float _Amplitude;
			float _Wavelength;
			float _Speed;

			
			struct Input {
				float2 uv_MainTex;
			};
		

			void vert(inout appdata_full vertexData) {
				float3 p = vertexData.vertex.xyz;
				float k = 2 * UNITY_PI / _Wavelength;
				float noiseSample = tex2Dlod(_NoiseTex, float4(vertexData.texcoord.xy, 0, 0));

				p.y = _Amplitude*sin(k*(p.x - _Speed * _Time.y*noiseSample));
				//p.x = _Amplitude * cos((p.x - _Speed * _Time.y));
				vertexData.vertex.xyz = p;
			}

			void surf(Input IN, inout SurfaceOutputStandard o) {
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
			}
			ENDCG
		}
			FallBack "Diffuse"
}