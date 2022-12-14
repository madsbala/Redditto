/*

Projektet er lavet af Anders Væde, Daniel Brinkland og Mads Bagge Larsen



Det er et valg at vi ikke har tilføjet front-end-delen, da vi ikke kunne få den til at virke med vores API

Men API'en virker og er testet igennem API-kald med Postman.

Alle stier og eksempler er tilføjet et stykke kode, så dette kan testes



Programmet kan køres ved at køre en 'dotnet ef database update' og en 'dotnet run'



Der er som udgangspunkt 4 boards og 4 comments i Seed-dataen, som ligger i DbService

Metoderne i API'en er:

-GetBoards - Henter alle boards
sti: /api/boards

-GetComments - Henter alle comments med et specifikt board-id
sti: /api/boards/{id}/comments

-GetBoard - Henter et board med et specifikt id 
sti: /api/boards/{id}

-CreateBoard - Opretter et nyt board. Der skal kun bruges en Header, men der kan også sættes en Author på.
Hvis der ikke oplyses en Author bliver denne sat til 'Anonymous'. Tidspunkt bliver sat på med en DateTime.Now
sti: /api/post - sendes med som JSON

{
    "Header" : "et eksempel", --Indholdet
    "Author" : "en frivillig person"  --kan udelades
}

-CreateComment - Opretter en ny kommentar. Der skal bruges et BoardID og en Text, men Author behøves ikke.
Hvis der ikke oplyses en Author bliver denne sat til 'Anonymous'. Tidspunkt bliver sat på med en DateTime.Now
sti: /api/comment - sendes med som JSON

{
    "BoardID" : "1", --Knytter kommentaren til et specifikt board
    "Text" : "en testkommentar", --Indholdet
    "Author" : "Darth Vader"  --Kan udelades
}

-UpvoteBoard - Upvoter et board ved hjælp af BoardID
sti: /api/boards/{boardid}/upvote/

-DownvoteBoard - Downvote et board ved hjælp af BoardID
sti: /api/boards/{boardid}/downvote/

-UpvoteComment - Upvoter en Comment ved hjælp af CommentID
sti: /api/boards/comments/{commentid}/upvote

-DownvoteComment - Downvoter en Comment ved hjælp af CommentID
sti: /api/boards/comments/{commentid}/downvote

*/

