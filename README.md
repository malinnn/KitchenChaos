# Kitchen Chaos - Proiect Grafica

## In ce consta proiectul ?
Acest proiect consta intr-un mic joc realizat in programul Unity, cu o idee de baza relativ simpla, care a fost realizat si ulterior modificat pentru a intalni cerintele date.

## Despre ce este jocul si care este scopul lui ? 
Jocul este unul simplu si are ca idee de baza un cooking game, in care din cateva in cateva secunde se vor primi comenzi (retete), care trebuie completate intr-un anumit timp. In interiorul proiectului,
rata de generare a retetelor si a timpului de joc se pot modifica in interiorul proiectului, aceste valori fiind private dar modificabile cu atributul [SerializeField]. La expirarea timpului, jocul se
va termina, dar se poate da drumul la alta tura, progresul devenind automat 0.

## Date tehnice despre joc

### Meniuri si interfetele grafice

Primul meniu cu care se intra in contact este meniul principal, care este unul simplut, avand 2 butoane : Play pentru a incepe jocul si Quit pentru a inchide aplicatia.

<p align="center"><img width="652" alt="image" style="width:60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/e46488d9-8cc6-4182-ae97-123c48d96ec9"></p>

Dupa apasarea butonului Play, va incepe jocul, care are o interfata grafica usor de inteles, prin care se pot vedea retetele sau comenzile care apar, un countdown pentru inceperea scurgerii timpului si un 
cerc de scurgere al timpului.

<p align="center"><img width="651" alt="image" style="width:60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/b1b7f546-986e-43bb-8622-3f8f7c18a0db"></p>

Alt meniu existent este cel de Pause, care se acceseaza prin apasarea butonul ESC, si contine 3 optiuni : Resume pentru a relua jocul, Options pentru a accesa diverse setari ale jocului si Main Menu
pentru a reveni in meniul principal, de start.

<p align="center"><img width="654" alt="image" style="width:60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/44f0d8b5-feed-4d64-83e7-90ce3327537c"></p>

Daca se apasa pe Options, vor aparea diverse setari ale jocului, adica volumele sunetelor si a muzicii, dar si keybind-urile de baza ale jocului. Aici exista si butonul de Cancel, care inchide meniul
setarilor.

<p align="center"><img width="649" alt="image" style="width:65%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/817f9967-db3a-472d-bc8c-7d3e56d8d93e">

### Afisarea obiectelor 3D

Acest lucru se realizeaza prin intermediul engine-ului specific programului Unity, numit Unity Engine, care suporta afisarea atat a obiectelor 2D, cat si a celor 3D prin intermediul Rendering Pipeline-ul lor. 
Cateva dintre lucrurile folosite
in acest proiect, de care dispune Unity sunt : scene, obiecte 3D, componenta Transform, materiale si shadere, camera.

### Transformari avansate

Cele 5 transformari avansate cerute sunt : translatie, rotatie, scalare, deformare si oglindire.
Translatia are loc prin intermediul sistemului de movement, care este folosit pentru interactionarea cu player-ul. De asemenea, fiind un cooking game, player-ul va tine in mana alimente sau farfuria
cu alimente care se va translata in acelasi timp cu jucatorul, astfel oferind acel aspect al actiunii de tinere in mana.
Rotatia se poate spune ca se realizeaza prin intermediul movementului, daca se apasa individual cate o tasta, care va indrepta player-ul in directia opusa a celei actuale. Desi acest lucru se intampla
si aici, am adaugat optiunea de rotire instanta a player-ului cu 90 grade, prin apasarea tastei ";".
Scalarea am implementat-o pentru a adauga un feeling mai distractiv al jocului, mai exact prin apasarea tastelor "," si "." se va scala player-ul cu o valoare hardcodata, cu care se va micsora sau mari
player-ul.
