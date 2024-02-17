# Kitchen Chaos

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

Cele 5 transformari avansate cerute sunt : translatie, rotatie, scalare, deformare si oglindire.<br>
***Translatia*** are loc prin intermediul sistemului de movement, care este folosit pentru interactionarea cu player-ul. De asemenea, fiind un cooking game, player-ul va tine in mana alimente sau farfuria cu alimente care se va translata in acelasi timp cu jucatorul, astfel oferind acel aspect al actiunii de tinere in mana.<br>
***Rotatia*** se poate spune ca se realizeaza prin intermediul movementului, daca se apasa individual cate o tasta, care va indrepta player-ul in directia opusa a celei actuale. Desi acest lucru se intampla si aici, am adaugat optiunea de rotire instanta a player-ului cu 90 grade, prin apasarea tastei ";". Aici, m-am folosit de metoda atributului transform, mai exact transform.Rotate().
<p align="center"><img width="270" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/951a6e45-4b27-4f6a-88a9-093601b6e972"></p>

***Scalarea*** am implementat-o pentru a adauga un feeling mai distractiv al jocului, mai exact prin apasarea tastelor "," si "." se va scala player-ul cu o valoare hardcodata, cu care se va micsora sau mari player-ul. Aici, m-am folosit de proprietatea transform.localScale.
<p align="center"><img width="287" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/7058396c-b3bd-44aa-ae5f-68ed06b0546c"></p>

***Deformarea*** am implementat-o cu acelasi scop al scalarii, aici fiind vorba despre largirea sau micsoarea player-ului pe axa X, mai exact va "ingrasa" player-ul, prin intermediul butoanelor "[" si "]".
<p align="center"><img width="372" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/f1bd969c-7f71-4a1e-962d-9132050ebc4f"></p>

***Oglindirea*** a fost folosita pentru crearea unei oglinzi, care este amplasata in fata player-ului. Acest lucru a fost realizat prin crearea unui plan, a unei texturi nou creata, dar si a unei
camere, prin intermediul carora se constituie aceasta oglinda.


### Shader Programming

Acest lucru l-am realizat pentru a oferi un aspect mai placut al jocului, prin adaugarea unor componente obiectului Global Volume, care vine din start dupa crearea unei scene 3D.
<p align="center">
<img width="222" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/6cf701fb-1a31-436b-ad3a-58290199fc11">
<img width="223" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/640fe557-678f-49c8-b419-319f69fd1098">
</p>

### Iluminare

Acest lucru se realizeaza prin intermediul obiectului Directional Light, prin care se modifica felul in care bate lumina in scena, defapt in tot jocul.
<p align="center"><img width="232" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/8e0ed1b4-09ca-4ad9-8aec-9f6133288b7f"></p>

### Camere si vizualizare

Pentru vizualizarea jocului, se foloseste o camera pozitionata mai sus, in stilul unui joc de tip up-down.
<p align="center"><img width="652" alt="image" width="60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/c84f8979-acae-4b34-a057-d64ff6e5bb96"></p>

### Interactiune

Toate interactiunile se fac prin intermediul butoanelor, mai putin in meniuri unde se foloseste click-ul stanga al mouse-ului. Acestea se pot vedea si la inceputul jocului, cand player-ul va fi
intampinat de un UI, in care se vad bind-urile jocului.
<p align="center"><img width="650" alt="image" width="60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/30d238b7-4518-4b51-bd03-a7d534ca06f1"></p>

### Sunet

Pentru muzica, am creat un obiect MusicManager prin care se controleaza muzica din joc. De asemenea, in acest script este implementata si metoda pentru modificarea volumului muzicii.
<p align="center">
<img width="233" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/66664289-eca8-4391-8601-2d3ea7693939">
<img width="368" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/59889f81-5a6d-427f-a017-2b26440fb402">
</p>

Pentru restul sunetelor, am creat un obiect SoundManager prin care se controleaza SFX-urile. Aici, m-am folosit de Event-uri, carora li se da trigger in momentul interactiunii specifice.
<p align="center">
<img width="234" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/040ba15a-e154-45a9-9bc0-02cda0aeaf23">
<img width="400" alt="image" width="50%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/5a5c7a06-bd46-4949-a650-fd900f7a4eab">
</p>







