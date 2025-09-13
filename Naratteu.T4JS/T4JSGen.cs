using System.Text;
using Microsoft.CodeAnalysis;
using NiL.JS.Core;

[Generator]
public class T4JSGen : IIncrementalGenerator
{
    void IIncrementalGenerator.Initialize(IncrementalGeneratorInitializationContext ctx)
    {
        ctx.RegisterPostInitializationOutput(post =>
        {
            post.AddSource("T4JSAttribute.g.cs",/*lang=c#-test*/"""
            using System;
            namespace Naratteu.T4JS
            {
                [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
                public class T4JSAttribute(string js) : Attribute { }
            }
            """);
            var ss = ctx.AdditionalTextsProvider
                .Where(file => file.Path.EndsWith(".t4.js"))
                ;
            ctx.RegisterSourceOutput(ss, (_, file) =>
            {
                var te = new Context();
                var sb = new StringBuilder($"// Gen From {file.Path}\n");
                te.DefineVariable("echo").Assign(te.GlobalContext.ProxyValue(new Action<string>(echo => sb.AppendLine(echo)))); //todo: console.log로 하고싶음
                te.Eval(file.GetText()?.ToString());
                post.AddSource($"TT{DateTime.Now.Ticks}.g.cs", // todo: 적절한 이름을 생성해야합니다.
                sb.ToString());
            });
        });
        // 이렇게 탐색된 파일들에 대해 PostInitialization으로 등록해야 VisualStudio 상에서 생성된 소스에 접근이 가능했음.
        // 허나 단순 RegisterSourceOutput 으로는 안되는 이유는 알수가 없음. 버그인지?
        var attr = ctx.SyntaxProvider.ForAttributeWithMetadataName("Naratteu.T4JS.T4JSAttribute", (_, _) => true, (c, _) => c);
        ctx.RegisterSourceOutput(attr, (spc, source) =>
        {
            //todo: attribute 부분 생성
        });
    }
}