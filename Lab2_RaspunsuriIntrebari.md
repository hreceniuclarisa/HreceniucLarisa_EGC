HRECENIUC LARISA - GRUPA 3131A

LABORATOR 2 - TEMA 2

PROBLEME DE REZOLVAT

Nu am observat nicio schimbare la modificarea valorii constantei "MatrixMode.Projection".
3.1. Termenul de viewport se referă la dimensiunea unei ferestre sau a unei zone vizibile pe ecran specificată în coordonate precise, pixeli, care reprezintă coordonatele ecranului unde obiectele create de către utilizator vor fi redând.

3.2. Frames per second reprezintă numărul de cadre care se încarcă pe secundă.

3.3. Metoda OnUpdateFrame() este rulată automat pe ecran în pasul următor, când va fi realizată următoarea randare - control utilizator, actualizarea pozițiilor obiectelor, etc.

3.4. Redarea în modul imediat este un stil pentru interfețele de programare ale aplicațiilor din bibliotecile de grafică, în care utilizatorul apelează direct la afișarea obiectelor grafice pe afișaj sau în care datele care descriu primitivele de redare sunt inserate frame by frame direct într-o listă de comenzi (în caz de redare imediată a modului primitiv), fără utilizarea unei indirecții extinse la resursele reținute.

3.5. Ultima versiune de OpenGL care acceptă modul imediat este 4.6.

3.6. Metoda OnRenderFrame() este rulată atunci când se dorește randarea scenei grafice.

3.7. Metoda OnResize rulează de fiecare dată când fereastra își schimbă dimensiunile. Aceasta trebuie să ruleze cel puțin o dată pentru a încărca dimensiunile ferestrei în momentul rulării programului.

3.8. Parametrii metodei CreatePerspectiveFieldOfView() sunt: fieldOfView -> câmpul de vizualizare în direcția y în radiani aspectRatio -> aspectul de rație, care este definit ca lungimea împărțită la înălțime nearPlaneDistance -> distanța până la cel mai apropiat plan farPlaneDistance -> distanța până la cel mai departat plan