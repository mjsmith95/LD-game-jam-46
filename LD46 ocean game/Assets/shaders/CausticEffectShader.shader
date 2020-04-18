Shader "Custom/NewSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
		[Header(Caustics)]
		_CausticsTex("Caustics (RGB)", 2D) = "white" {}
		_Caustics_ST("Caustics ST", Vector) = (1,1,0,0) 
		_CausticsSpeed("Caustics Speed", Vector) = (2, 1, 0 ,0)


    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _CausticsTex;
		float4 _Caustics_ST;
		float2 _CausticsSpeed;
        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;

			// Caustics sampling
			// use uv mapping to smaple correct part of texture based off which part of geo we have to render 
			fixed2 uv = IN.uv_MainTex * _Caustics_ST.xy + _Caustics_ST.zw;
			//animating using untiy built in time 
			uv += _CausticsSpeed * _Time.y; 
			//smapling
			fixed3 caustics = tex2D(_CausticsTex, uv).rgb;
			// add to the albedo 
			o.Albedo.rgb += caustics;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
