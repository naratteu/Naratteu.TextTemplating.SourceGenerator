# Naratteu.T4JS

[T4 Text Templates](https://learn.microsoft.com/visualstudio/modeling/code-generation-and-t4-text-templates)을 [Source Generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators)와 접목해 활용하기 위해 다방면으로 시도했으나, 끝끝내 실패하여 인제 그냥 내멋대로 만들것임을 선포

T4 alternative, not T4

## Play

```bash
git clone https://github.com/naratteu/Naratteu.T4JS
cd Naratteu.T4JS
cd Naratteu.T4JS
dotnet pack -p:Version=0.0.1-test
dotnet run --project ../Playground # err
dotnet run --project ../Playground
# Hello, 1764!
```

아래와같은 방식으로 동일 nuget버전에 대한 캐시를 무시하고 반복테스트 합니다.

```bash
docker run --rm -v ./../:/v mcr.microsoft.com/dotnet/sdk:8.0 dotnet run --project v/Playground
```

## Why [`Nil.JS`](https://github.com/nilproject/NiL.JS/)

소스제너레이터 라이브러리를 개발하는데는 여러 제약이 있는데, 추가 의존성이 없고 동기적으로 동작하는 JS엔진으로 선택함. 

외부패키지를 현패키지에 아예 내장시켜 배포하는 방식 등이 라이선스에 위배되거나 하진 않는지 조사필요.

## See Also

- https://github.com/CptWesley/T4.SourceGenerator
- https://github.com/JakeSays/TextTemplating
- https://github.com/jgiannuzzi/T4.Build
- https://github.com/ufcpp/ScribanSourceGenerator
- https://github.com/peachpiecompiler