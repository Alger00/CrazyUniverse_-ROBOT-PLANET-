# CrazyUniverse_(ROBOT PLANET)

## Valitud maailm ja rakenduse eesmärk

Valisin maailma **Robot Planet**, kus erinevat tüüpi robotid elavad samas maailmas, kuid käituvad erinevalt. Eesmärk on demonstreerida objektorienteeritud programmeerimise põhimõtteid nagu pärilus, liidesed, polümorfism ja abstraktsed klassid. Kasutaja saab roboteid lisada, eemaldada, valida ning kasutada nende erinevaid tegevusi.

---

## Kävitamisejuhend

1. Klooni GitHubi repository oma arvutisse.
2. Ava lahendus Visual Studios.
3. Käivita WPF projekt.
4. Pane ekraan **Fullscreen Mode**.
5. Sisesta roboti nimi.
6. Vali roboti tüüp.
7. Vajuta **Add Robot**.
8. Testi tegevusi kasutades nuppe:
    - Work
    - Crazy Action
    - Charge
    - Scan
    - Repair
    - (Mõned robotid ei saa teha tegevusi nagu **Scan** ja **Repair**)
9. Jälgi roboti andmeid ja tegevusi logiaknas.

---

## Klassihierarhia ja liidesed

### Klassihierarhia

Robot
|
|-- CleanerBot
|-- ExplorerBot
|-- RepairBot
|-- GuardBot (Kaasüliõpilase loodud)

### Robot

Robot on abstraktne baasklaas, mis sisaldab kõigile robotitle ühiseid omadusi ja meetodeid:

- Name
- BatteryLevel
- Work()
- CrazyAction()

### Liidesed

#### IChargeable

Võimaldab roboti akut laadida.

Charge()

#### IScan

Võimaldab robotil objekte skaneerida.

Scan()

#### IRepair

Võimaldab robotil teisi roboteid parandada.

Repair()

### Liideste kasutamine

- CleanerBot rakendab liidest IChargeable.
- ExplorerBot rakendab liideseid IChargeable ja IScan.
- RepairBot rakendab liideseid IChargeable ja IRepair.
- GuardBot rakendab liideseid IChargeable ja IScan. (Kaasüliõpilase loodud)

---

## CrazyAction tegevused ja olekureeglid

Igal robotil on oma unikaalne CrazyAction() tegevus.

### CleanerBot

Poleerib banaani nii kaua, kuni see näeb välja nagu kuld.

### ExplorerBot

Leiab planeedi, mis on täielikult valmistatud pitsast.

### RepairBot

Ehitab tantsiva kosmoselaeva.

### GuardBot

Pommitab vaenlase planeeti.

### Olekureeglid

- Kõik robotid alustavad 100% akuga.
- Erinevad tegevused kulutavad akut.
- Charge() suurendab aku taset.
- Aku ei saa ületada 100% ega minna alla 0%.
- Robot ei saa tegevust sooritada, kui tal ei ole piisavalt akut.
- Vigane tegevus ei muuda roboti kehtivat olekut.

---

## Kontrollitud kasutusjuhud

### 1. Uue roboti lisamine

Kasutaja sisestab roboti nime, valib tüübi ning lisab roboti nimekirja.

### 2. Roboti eemaldamine

Kasutaja valib roboti ning eemaldab selle nimekirjast.

### 3. Work tegevuse käivitamine

Kasutaja valib roboti ning käivitab Work() meetodi. Aku väheneb ning tegevus lisatakse logisse.

### 4. CrazyAction tegevuse käivitamine

Kasutaja käivitab CrazyAction() meetodi. Kuvatakse teemakohane sõnum ning aku väheneb.

### 5. Aku laadimine

Kasutaja kasutab Charge() tegevust ning roboti aku suureneb.

### 6. Skaneerimine

Kasutaja valib ExplorerBoti ning kasutab Scan() tegevust.

### 7. Parandamine

Kasutaja valib RepairBoti ning kasutab Repair() tegevust.

---

## Kasutatud WPF UI element

### ProgressBar

Kasutasin ProgressBar elementi roboti aku taseme kuvamiseks.

### Põhjendus

ProgressBar annab kasutajale kiire ja visuaalse ülevaate roboti aku seisundist. Aku muutusi on lihtsam jälgida kui ainult numbrilise väärtuse kaudu ning see muudab kasutajaliidese selgemaks ja kasutajasõbralikumaks.

---

## Git koostöö

### Kaasüliõpilane

Nimi: **Jan-Eerik Laende**

### Issue

https://github.com/Alger00/CrazyUniverse_-ROBOT-PLANET-/issues/1

### Pull Request

https://github.com/Alger00/CrazyUniverse_-ROBOT-PLANET-/pull/3

---

## AI kasutamine

Kasutasin CoPilotit projekti planeerimisel, WPF kasutajaliidese loomisel ja probleemide lahendamisel.

Kontrollisin kogu koodi ise üle, testisin programmi tööd ning tegin vajadusel parandusi ja muudatusi enne lõplikku esitamist.
