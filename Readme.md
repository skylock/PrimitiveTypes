# Tipuri primitive
 
1. Pavaj pentru piață
 
primăria a decis să paveze piața mare din centru orașului cu piatră cubică
piața e un dreptunghi de `m x n`, iar piatra cubică are dimensiunea de `a x a`
de câte bucăți de piatră e nevoie pentru a acoperi piața?
piatra cubică se vinde la bucată, deci nu pot fi cumpărate jumătăți
 
exemplu: dacă piața e de 6x6 și piatra cubică e de 4x4, rezultatul trebuie să fie 4
 
2. Coloane excel
 
primele 26 de coloane din excel sunt marcate cu literele alfabetului
după care continuă cu combinații de câte două litere, astfel coloana 27 este AA, 28 - AB, iar coloana 52 cu AZ
după ZZ, se continuă cu combinații de 3 litere
 
dacă se dă numărul coloanei află care e combinația de litere corespunzătoare
 
3. Sit arheologic
 
într-un sit arheologic s-au descoperit 3 coloane care aparțineau unei clădiri
dacă se dau coordonatele celor 3 coloane, află aria minimă a clădirii
coordonatele sunt numere cu 6 zecimale
 
exemplu: (0.000000, 0.000000), (1.000000 1.000000) și (0.000000, 1.000000) rezultatul este 1.000000
 
4. Dobândă bancă descendentă
 
vrei să iei un credit de 40k euro de la bancă
dobânda anuală cerută de bancă e de 7.57%
creditul e pentru o perioadă de 20 ani
contractul prevede restituirea în rate descrescătoare
 
calculează ce rată trebuie plătită în luna martie din al celui de al 4-lea an?
generalizează pentru orice sumă, perioadă și dobândă
 
5. Pepenele
 
doi prieteni au cumpărat un pepene de X kg, și doresc să îl împartă
singura lor dorință e ca fiecare să primească un număr par de kg din pepene
e ok și dacă nu primesc aceeași cantitate
 
scrie un program care răspunde cu DA dacă pepenele poate fi împărțit cum își doresc cei doi prieteni, și cu NU în caz contrar
 
6. Sportiv
 
un sportiv a efectuat mai multe runde de pregătire
în prima rundă a efectuat o singură repetiție
în a doua rundă a efectuat două repetiții
și tot așa până la runda `N` când a ajuns la `N` repetiții
după care a început să scadă din nou nr de repetiții, cu câte 1/rundă
asta până ce a ajuns din nou la o singură repetiție
 
ajută-l pe sportiv să calculeze câte repetiții a efectuat în total
 
7. Trenuri
 
două trenuri pornesc în același timp unul către celălalt cu o viteză constantă de `X` km/h
când cele două trenuri sunt la o pătrime din distanța inițială, o pasăre aflatăpe primul tren pornește în zbor către al 2-lea tren cu o viteză de 2X
imediat ce a ajuns la el se întoarce către primul și repetă asta până când cele două trenuri se întâlnesc
 
care e distanța zburată de pasăre?
 
8. Capre
 
în `X` zile `Y` capre mănâncă `Z` kg fân
câte kg de fân mănâncă `Q` capre în `W` zile?
 
9. Ciuperci
 
după ploaie au răsărit `N` ciuperci, unele roșii iar altele albe
cele roșii îs de X ori mai multe
câte ciuperci sunt de fiecare?
 
10. Parchet
 
trebuie pus parchet laminat într-o cameră de `N x M` mp
dimensiunea unei plăci de parchet e de `A x B` mp
pierderile sunt de 15%
de cât parchet e nevoie?

## Criptare și decriptare

doi prieteni s-au hotărât să își cripteze mesajele între ei
metoda aleasă de ei e ca mesajul original să fie scris pe coloane
doar literele vor fi notate
mesajul criptat fiind opținut prin parcurgerea liniilor de la stânga la dreapta
dacă mesajul e mai mic, se completează cu litere aleatoare
număr de coloane e secret, știut doar de ei
ajută-i pe cei doi să își cripteze/decripteze mesajele

exemplu: "nicaieri nu e ca acasa" și 4 coloane

    n e e a
    i r c s
    c i a a
    a n a x
    i u c w

## Loto 6 din 49

vrei să participi la jocul de noroc 6 din 49 cu o singură variantă (simplă)
calculează ce șanse ai să câștigi la categoria I (6 numere)?
calculează ce șanse ai să câștigi la categoria II (5 numere)?
calculează ce șanse ai să câștigi la categoria III (4 numere)?


#Operații în bază
Ai un număr zecimal transformă-l în baza doi, reprezentat ca și un array de byte (byte[]).

Petru un număr transformat implementează operațiile:
1. NOT, AND, NOT, OR, XOR
2. RightHandShift și LeftHandShift (shiftare de biți la dreapta și la stânga)
3. LessThan
4. Adunare și scădere
5. Înmulțire și împărțire
6. Folosește-te de LessThan pentru a implementa și alți operatori de comparare (GraterThan, Equal, NotEqual)

Doar pentru numere pozitive.
Poți generaliza transformarea și operațiile de la 3-6 pentru o bază aleatoare?

## Meteo

Un centru meteo publică zilnic temperaturile minime și maxime pentru fiecare zi.
Dacă ai datele publicate într-o lună, calculează:

1. Care e cea mai călduroasă zi
2. Care e cea mai friguroasă zi
3. Care e temperatura medie în luna dată (pe baza maximelor)
4. Calculează care a fost diferența maximă între temperaturile minime și maxime
5. Adaugă o nouă zi

## Inversare și înlocuire

Inversează un string folosind recursivitatea.
Înlocuiește un caracter dintr-un string cu un alt string.

## Calculator

Scrie un program care imită un calculator de buzunar în formă prefixată.
Operațiile posibile sunt:
1. adunare/scădere
2. înmulțire/împărțire
3. suportă numere reale

Notă: În forma prefixată operatorii apar înainte operanzilor.
Exemple pentru format prefixată:
1. ` * 3 4 ` e echivalent cu `3 * 4`
2. ` * + 1 1 2 `, e echivalent cu `(1 + 1) * 2`
3. ` * / * + 56 45 45 3 0.75 ` e echivalent cu ` ((56 + 45) * 45) / 3 * 0.75 `

## Turnurile din Hanoi

Călugării dintr-un templul din Benares trebuie să mute 64 de discuri de pe un turn pe altul.
În afară de cele două turnuri mai au la dispoziție un singur alt turn care e suficient de sacru pentru a putea fi folosit.
Cele 64 de discuri au dimensiuni diferite. Iar călugării trebuie să respecte două reguli:
1. un singur disc poate fi mutat la un moment dat
2. un disc mai mare nu poate fi mutat peste un disc mai mic

## Triunghiul lui Pascal

Generează triunchiul lui Pascal pentru un nivel dat folosindu-te de recursivitate.
Triunghiul lui Pascal:

                                1
                           1        1
                       1        2       1
                   1       3       3       1
               1       4        6      4      1
            1       5       10      10      5     1
         1     6       15       20      15      6     1
