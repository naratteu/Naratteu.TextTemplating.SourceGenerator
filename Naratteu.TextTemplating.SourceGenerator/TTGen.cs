using Mono.TextTemplating;
using Microsoft.CodeAnalysis;

[Generator]
public class TTGen : IIncrementalGenerator
{
	void IIncrementalGenerator.Initialize(IncrementalGeneratorInitializationContext ctx)
	{
		var ss = ctx.AdditionalTextsProvider.Where(f => Path.GetExtension(f.Path) is ".t4" or ".tt").Select((file, c) =>
		{
			ctx.RegisterPostInitializationOutput((ctx) =>
			{
				var te = new TemplatingEngine();
				te.UseInProcessCompiler(); // 호출하지 않았을때와의 차이를 모르겠습니다. 의미가 있나요?
				ctx.AddSource($"TT{DateTime.Now.Ticks}.g.cs", // todo: 적절한 이름을 생성해야합니다. 
				te.ProcessTemplateAsync(file.GetText()?.ToString(), new TemplateGenerator()).Result);
			});
			return file;
		});
		// 이렇게 탐색된 파일들에 대해 PostInitialization으로 등록해야 VisualStudio 상에서 생성된 소스에 접근이 가능했음.
		// 허나 단순 RegisterSourceOutput 으로는 안되는 이유는 알수가 없음. 버그인지?
		ctx.RegisterSourceOutput(ss, (a, b) => { });
	}
}