Powerful and extandable HTML generation library in C# using .NET Standard 1.3

````c#
using static Nerven.Htmler.Core.HtmlBuilder;

var document = Document(
    htmlTag(
        headTag(
            metaTag(
                charsetAttr(Encoding.UTF8)),
            titleTag(
                Text("Htmler Demo"))),
        bodyTag(
            divTag(
                Comment("makes it easy -- really easy -- to generate HTML correctly and securily --> (look, this comment is properly escaped)"),
                pTag(
                    idAttr("paragraph-with-id"),
                    classAttr("important-paragraph"),
                    Raw("you are wrong and I'm right, this shouldn't be escaped: <<< (while inheretly secure, Htmler doesn't stop when you insist)"),
                    divTag(
                        Text("Supports flag attributes"),
                        inputTag(Attribute("disabled", null)),
                        buttonTag(Attribute("disabled", null))),
                    aTag(
                        imgTag(
                            Attribute("src", "test.png")),
                        spanTag(Text("It's > with escaped text!"))))),
            pTag(
                Text("Well, to avoid issues with whitespace affecting layout, "),
                Text("default mode generates no whitespace or newlines at all, "),
                Text("but one can turn on some newlines if needed.")))));

var s = document.WriteReadableToString();
````

becomes

````html
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Htmler Demo</title>
</head>
<body>
<div>
<!--makes it easy - - really easy - - to generate HTML correctly and securily - -> (look, this comment is properly escaped)-->
<p id="paragraph-with-id" class="important-paragraph">you are wrong and I'm right, this shouldn't be escaped: <<< (while inheretly secure, Htmler doesn't stop when you insist)
<div>Supports flag attributes
<input disabled>
<button disabled></button>
</div>
<a>
<img src="test.png">
<span>It's &gt; with escaped text!</span>
</a>
</p>
</div>
<p>Well, to avoid issues with whitespace affecting layout, default mode generates no whitespace or newlines at all, but one can turn on some newlines if needed.</p>
</body>
</html>
````
