using T4.SourceGenerator.Example;
Console.WriteLine($"Hello, {Squares.Squared42}!");

//이하 미구현 기능입니다.

[Naratteu.T4JS.T4JS("""
echo(`
public void HelloWorld() => Console.WriteLine("Hello, World");
`)
""")]
partial record GenClass
{
    [Naratteu.T4JS.T4JS("""
    echo(`
    return 1;
    `)
    """)]
    public partial int GenMethod();
    public partial int GenMethod() => default;
}