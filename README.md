[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/raLu7W0G)


# CHESS
Jelikož během praxí nebudu mít tolik času na dělání tohoto projektu, začal jsem na něm již před týdnem dělat. Repozitář jsem si již vytvořil:
https://github.com/Fuficek/game-chess

příště budu commitovat sem.

Game Rules //TODO

https://en.wikipedia.org/wiki/Algebraic_notation_(chess) - Board repesentation
https://en.mimi.hu/chess/long_algebraic_notation.html - Moves



## Commit 1 - Update 14.5.2023
* Jelikož mi byla zamítnuta verze používající windows forms pro generování GUI, byl jsem proto nucen předělat celou hru do konzole. V prvním commitu je hlavní práce za víkend *12.-14.5.2023.*
Jedná se o základní zobrazování šachovnice a většina času byla investována do co nejpříznivějšího generování šachovnice, a optimalizacím v algoritmu vykreslování. Také v každé třídě šachových figurek jsou implementovány metody pro kontrolu legálních tahů. 
* Abych nemusel pokaždé procházet celé pole šachovnice pro nalezení hledané figury, uchovávám pozici jednotlivých figurek v jejich třídách, což obstarává komplikovanější a hůře čitelný, ale rychlejší kód. Další možné řešení bylo použít dictionary pro uchovávání pozic jednotlivých figur, ale kód byl poté výrazně pomalejší.

## Commit 2 - Update 20.5.2023
* Zprovoznil jsem pohyb jednotlivých figurek na poli společně se základní kontrolou legálních tahů, napříkald jezdci se hýbou pouze po Lkách, střelci pouze po diagonálách, apod.
* Kód jsem též lehce přepracoval ohleně vykreslování herního pole, takže pro vykreslení používám stejnou funkci pro hledání figur, jako všude jinde v kódu
* kód je ošetřen výjimkami

## Commit 3 - Update 26.5.2023
* TRVALO MI 6 DNÍ (večerů) IMPLEMENTOVAT POHYB KRÁLOVNY A PĚŠÁKŮ
* stále nefunguje rošáda ani en passant, ale na to se asi vykašlu, protože musím dělat jiné projekty do školy
* zatím jsem strávil na tomto projektu cca 28hodin, a už si myslím že to stačí na takto komplikované téma

## Commit 4 - Update 27.5.2023
* Rošáda je plně funkční pro oba hráče na obě strany a tady asi zakončím vývoj herní mechaniky a budu se soustředit na projekt na weby (vůbec se mi do toho nechce)
* kod je v této fázi plně funkční a ošetřen výjimkami, vykreslovací mechanika, ověřování legálních tahů atd, je plně funkční a nově i bez stackoverflow errorů, které jsem kvůli rekurzi funkcí řešil velmi často. Stačí mi pouze napsat herní pravidla a ukládání aktuální pozice do souboru, pravděpodobně se vykašlu ne generování <a href="https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation">FEN</a> stringů, což byl původní plán, jenže jsem neimplementoval mechaniku EN Passant, tak nemohu tuto metodu použít. Na en passantu jsem pracoval, ale kvůli časové tísni si myslím že bych pak projekt nedokončil.

### Použitá probraná látka
Jedním z mých cílů, je procvičit si použití co největšího objemu probrané látky (i když mnoho z ní nemá využití v mém projektu), proto jsem udělal tento list:
 * [X] POLE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Array.aspx
 * [X] TŘÍDY A OBJEKTY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Class.aspx
 * [X] VÝJIMKY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Exception.aspx
 * [X] DĚDIČNOST - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Inheritence.aspx
 * [X] ZAPOUZDŘENÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Encapsulation.aspx
 * [X] POLYMORFISMUS - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Polymorphism.aspx
 * [X] STATICKÉ TŘÍDY A ČLENY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Static.aspx
 * [X] ABSTRAKCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Abstraction.aspx
 * [X] ROZHRANÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Interface.aspx
 * [ ] PŘETÍŽENÍ OPERÁTORŮ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-OperatorOverloading.aspx
 * [ ] STRUKTURA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Struct.aspx
 * [ ] ZÁZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Record.aspx
 * [X] S.O.L.I.D. - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-SOLID.aspx
 * [ ] GERERIKA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Generics.aspx
 * [ ] KOLEKCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Collection.aspx
 * [X] SEZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Col-List.aspx
 * [ ] SLOVNÍK - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Dictionary.aspx
 * [ ] FRONTA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Queue.aspx
 * [ ] ZÁSOBNÍK - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Stack.aspx
 * [ ] DELEGÁTY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Delegates.aspx
 * [X] ROZŠIŘUJÍCÍ METODY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-ExtensionMethods.aspx
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
