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

//Найти индекс минимального элемента

let MinEl list = 
    let rec minel list min indM indEL =
        match list with
        |[]->indM
        |h::tail -> 
            let newMin =if h<min then h else min
            let newInd = if h<min then indEL else indM
            minel tail newMin newInd (indEL+1)
    minel list list.Head 0 0

[<EntryPoint>]
let main argv =
    let l = readData
    Console.WriteLine("Индекс минимального элемента списка: ")
    let res =List.findIndex(fun x ->( x = MinEl l)) l
    Console.WriteLine(res)
    0