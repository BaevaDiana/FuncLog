open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail 
 
//Дан масиив.Найти элементы, расположенные между первым и последним максимальным

//поиск индекса первого максимального элемента
let IndexFirstMaxEl list = 
    let rec indfirstmaxel list max indM indEL=
        match list with
        |[]->indM
        |h::tail -> 
            let newMax = if h>max then h else max
            let newInd = if h>max then indEL else indM
            indfirstmaxel tail newMax newInd (indEL+1)
    indfirstmaxel list list.Head 0 0 


//поиск индекса последнего максимального элемента
let IndexLastMaxEl list = 
    let rec indexlastmaxel list max indM indEL=
        match list with
        |[]->indM
        |h::tail -> 
            let newMax = if h>=max then h else max
            let newInd = if h>=max then indEL else indM
            indexlastmaxel tail newMax newInd (indEL+1)
    indexlastmaxel list list.Head 0 0 

//построение нового списка(элементы выписываем)
let NewList list  = 
    let indexFirst = IndexFirstMaxEl list //индекс первого максимум
    let indexLast = IndexLastMaxEl list //индекс второго максимума
    let rec newlist (list1:'int list) ind1 ind2 indEl newList = 
        if indEl = ind2 then newList
        else 
            let newNewList=
                if indEl> ind1 then newList @ [list1.Head]
                else newList
            newlist list1.Tail ind1 ind2 (indEl+1) newNewList
    newlist list indexFirst indexLast 0 []

[<EntryPoint>]
let main argv =
    Console.WriteLine("Элементы, расположенные между первым и последним максимальным:")
    readData |> NewList |> writeList
    0 