Descrierea a cum functioneaza sitemul de behaviour tree
Inainte sa citesti asta trebuie sa stii ce sunt Composite(Sequence,Selector)
si cum functioneaza in general un arbore

o scurta descriere.
fiecare nod poate sa aiba urmatoarele stari:
-> Success,Running,Failure,None(pt initializare)
in cod asta este un enum si se afla in Status.cs
-> Nodurile cele mai de jos reprezinta actiunile, in cod sunt reprezentate
de clasa ActionNode.cs
-> Nodurile Composite sunt nodurile care reprezinta un fel de operatori
logici adica 
->Sequence o sa fie SUCCESS daca toate nodurile sunt SUCCESS
(un fel de && si)
->Selector o sa fie SUCCESS daca unul dintre noduri este SUCCESS
(un fel de sau)

Fiecare clasa pe rand:

1. Status.cs -> contine doar enum-ul Status cu Success,Running,Failure,None
2. BehaviourTree.cs
-> definitia behaviourtree-ului
-> are o radacina de tip Node
-> exista un constructor(functia cu care se intializeaza clasa) care 
are ca paramatru un nod, si atunci acel nod devine radacaina.
Adica fac BehaviourTree(new Selector(..)) de exemplu
adica radacina este un selector.
-> functia de Run (foarte importanta)
atata timp ca starea curenta este de running sau nu exista atunci evalueaza
radacina
-> este apelata fiecare frame in Update() in TestAi.cs

un exemplu 	
		Sequence
MoveToLocation	RotateObj   Sequence
				ChangeColor

(exemplul acesta se afla in Start() TestAI.cs

movetolocation se misca pana la (0,0,0), success cand ajunge, running 
in timp ce merge
Rotateobj -> roteste obiectul pentru 3 secunde cu rotatia : (0,120,0)
ChangeColor -> schimba culaorea cubului in 10 secunde in negtru

Ce se va intampla?
1. radacina.Evalate() se executa.
2. MoveToLocation se executa, => statusul e running atunci si radacina e running
3.  in urmatorul frame din Update() radacina.Evaluate() se executa.
4. MoveToLocation se evalueaza => sa ziceam ca nu a ajuns inca,deci tot running
-> radacina running
5. pasul 1 etc etc pana cand se termina MoveToLocation cu succes.
6. Se evalueaza RotateObj
7. Initial RotateObj returneaza Running pt ca obiectul inca nu a fost rotitit la 120 de grade.
dureaza 3 secunde(presupunem ca de abia in secunda asta a inceput rotirea)
8. RotateObj este running => radacina running.
9. alt frame de update, => rotate obj running => radacina running
9. s-a terminat cu rotateobj, a returnat succes urmeaza urmatoare secventa.
...etc


Node.cs
Node() -> constructor normal
public Node(Delegate execute, Action start = null, Action exit = null, params object[] args)
ok putin complicat nu? :)))
pai Delegate e o actiune si Action la fel deci sa zicem ca cat de ok
dar ce e aia cu params?
pai initial eu puneam tot un Action la execute dar poate ai nevoie de un parametru
la actiune.

sa zicem MoveLocation(cameracontrol) pai atunci aia cu action da eraore. asa functioneaza
c#.. si de aia avem un vector de parametrii la final.. ala inseamna ce parametrii avem

    protected virtual void Start()
    {
        if (startAction != null)
        {
            Debug.Log("Starting : " + nameStart);
            startAction?.Invoke();
        }
    }
-> avem o functie Start() care se apeleaza prima oara cand intram in nod(se apeleaza de 
functia evaluate dar vedem mai incolo)
protected? pai noi putem aveam public/private/protecred

public poate vedea oricine care are in mana clasa Nod.
private se poate acesa variabila doar din clasa
protected poate accesa orice clasa care il mosteneste Nod
care e fix cazul nostru, noi vrem ca Sequence,Selector,ActionNode sa acceseze asa ceva.
deci asta facem cu protected.

virtual? hm why virtual? pai virutal inseamna ca functia poate fi modificata de clasele
care o mostenesc.. adica celelalte clase Sequence,Selector,ActionNode. etc

startAction?.Invoke() invoca actiunea

ce inseamna actiunea?
inseamna ca eu pot pune o functie ca parametru
Node(functie Start) -> gata

functia evaluate. daca statusul initial e none atunci Start
se executa

dupa daca a iesit din running adica e succes sau failure apeleaza exit()

cam asta e tot



















