# HLang compiler in C#

This is a personal project of mine where I am writing a compiler for my own language in c#

## Features
Lexical Analysis of the following lexemes:
  - Integer numbers
  - Single character lexemes ( + , - , * , / )
  - End of File
  
Lexical Error messages including line/column numbers  


## Example

```sh
$ ./HLang
1 + 2 * 3 / 5
<NumberToken, "1">
<PlusToken>
<NumberToken, "2">
<StarToken>
<NumberToken, "3">
<SlashToken>
<NumberToken, "5">
<EOFToken>
```

Example of catching a lexical error:
```sh
$ ./HLang
1 + 2 + ^£$*^$rihihsih
<NumberToken, "1">
<PlusToken>
<NumberToken, "2">
<PlusToken>
Illegal Token '^' at (1:9)
```
