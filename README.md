[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/raLu7W0G)


# CHESS
Jelikož během praxí nebudu mít tolik času na dělání tohoto projektu, začal jsem na něm již před týdnem dělat. Repozitář jsem si již vytvořil:
https://github.com/Fuficek/game-chess

příště budu commitovat sem.


## Commit 1 - Update 14.5.2023
* Jelikož mi byla zamítnuta verze používající windows forms pro generování GUI, byl jsem proto nucen předělat celou hru do konzole. V prvním commitu je hlavní práce za víkend *12.-14.5.2023.*
Jedná se o základní zobrazování šachovnice a většina času byla investována do co nejpříznivějšího generování šachovnice, a optimalizacím v algoritmu vykreslování. Také v každé třídě šachových figurek jsou implementovány metody pro kontrolu legálních tahů. 
* Abych nemusel pokaždé procházet celé pole šachovnice pro nalezení hledané figury, uchovávám pozici jednotlivých figurek v jejich třídách, což obstarává komplikovanější a hůře čitelný, ale rychlejší kód. Další možné řešení bylo použít dictionary pro uchovávání pozic jednotlivých figur, ale kód byl poté výrazně pomalejší.


### Použitá probraná látka
Jedním z mých cílů, je procvičit si použití co největšího objemu probrané látky, proto jsem udělal tento list:
 * [X] POLE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Array.aspx
 * [X] TŘÍDY A OBJEKTY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Class.aspx
 * [X] VÝJIMKY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Exception.aspx
 * [X] DĚDIČNOST - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Inheritence.aspx
 * [X] ZAPOUZDŘENÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Encapsulation.aspx
 * [X] POLYMORFISMUS - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Polymorphism.aspx
 * [X] STATICKÉ TŘÍDY A ČLENY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Static.aspx
 * [X] ABSTRAKCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Abstraction.aspx
 * [ ] ROZHRANÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Interface.aspx
 * [ ] PŘETÍŽENÍ OPERÁTORŮ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-OperatorOverloading.aspx
 * [ ] STRUKTURA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Struct.aspx
 * [ ] ZÁZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Record.aspx
 * [X] S.O.L.I.D. - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-SOLID.aspx
 * [ ] GERERIKA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Generics.aspx
 * [ ] KOLEKCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Collection.aspx
 * [ ] SEZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Col-List.aspx
 * [ ] SLOVNÍK - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Dictionary.aspx
 * [ ] FRONTA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Queue.aspx
 * [ ] ZÁSOBNÍK - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Stack.aspx
 * [ ] DELEGÁTY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Delegates.aspx
 * [ ] ROZŠIŘUJÍCÍ METODY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-ExtensionMethods.aspx
 * [ ] LINQ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-LINQ.aspx
 * [ ] DATUM A ČAS - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-DateTime.aspx
 * [ ] STOPKY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Stopwatch.aspx
 * [ ] TESTOVÁNÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Testing.aspx
 * [ ] JEDNOTKOVÉ TESTOVÁNÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-UnitTesting.aspx
 * [ ] BENCHMARK - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Benchmark.aspx
 * [ ] ŘETĚZCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-String.aspx
 * [X] REGEX - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-RegularExpression.aspx
 * [ ] SOUBOROVÝ SYSTÉM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-FileSystem.aspx
 * [ ] ARGS - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-CommandLineArgs.aspx
 * [ ] TEXTOVÉ SOUBORY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-TextFile.aspx
 * [ ] BINÁRNÍ SOUBORY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-BinaryFile.aspx
 * [ ] ŠIFROVÁNÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Ciphers.aspx
 * [ ] AES - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-AES.aspx
 * [ ] RSA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-RSA.aspx
 * [ ] HASHOVÁNÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Hash.aspx
 * [ ] SPOJOVÝ SEZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-LinkedList.aspx
 * [ ] BINÁRNÍ STROM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-BinaryTree.aspx
 * [X] VÝSTUP NA KONZOLI - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Console.aspx
