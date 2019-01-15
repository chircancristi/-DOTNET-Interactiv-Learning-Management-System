# Interactive Learning Management System

## Echipă - Sărmăluțe fără smântâna
- Ardeleanu Gabriel-Angel
- Cabac Dorina
- Chircan Dan-Cristian
- Gaidur Bogdan
- Ploae Teodor 


### Iterația 1

- Crearea diagramelor C4 de nivel 1 și de nivel 2 și crearea unei diagrame de baze de date. (folderul documentation) 
- Structurarea codului în funcție de MVC.
- Data layerul și baza de date aferentă pentru studenți și profesori.

### Iterația 2 

- Realizarea unei arhitecturii pentru pagina web și un prototip pentru interfață
- Realizarea unui prototip pentru server 
- Finalizarea layerului pentru date 
- S-au stabilit următoarele microservicii<br> 
  a) User management<br>
  b) Courses management<br> 
  c) Answer/Questions management
 - Baza de date din iterația trecuta a fost împarțită în 3 baze de date mai mici penru  integrarea 
 microserviciilor menționate mai sus. 
 - S-au scris modelele pentru a obține și a scrie date in bazele de date menționate.
 
 ### Itereția 3
 
 - S-au adaugat în modele urmatoarele funcții:
    1) getStudentsFromCourseWithID
    2) getStudentByRoomID
    3) getAnswerFromQuestionID
    4) getQuestionsByRoomID
  - S-au scris controllerele pentru pagina de student/professor
  - S-au implementat urmatoarele functionalității
     1) Profesorul poate deschide o cameră
     2) Profesorul poate pune întrebării pe curs/camere
     3) Profesorul poate aleg răspunsul preferat la o întrebare  
     4) Studentul poate intra pe un room pe baza de token
     5) Studentul poate raspunde la întrebăriile de pe curs/room
     6) Studentul poate pune întrebării pe course 

  ### Iterația 4 
  - Profesorul poate alege daca raspunsul studentului este corect 
