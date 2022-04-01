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

//Необходиом разместить элементы расположенные до минимального в конце массива

//поиск индекса минимального элемента
let IndexOfMinEl list = 
    let rec indexofminel list min indM indEL=
        match list with
        |[]->indM
        |h::tail -> 
            let newMin = if h<=min then h else min
            let newInd = if h<=min then indEL else indM
            indexofminel tail newMin newInd (indEL+1)
    indexofminel list list.Head 0 0 

//построение списка (находим индекс минимального элемента и сравниваем с индексом текущего элемента ->добавляем в соответствующий список)
let BeforeMin list = 
    let indexMin = IndexOfMinEl list
    let rec beforemin list indMin indEl ListBefMin ListAfter = 
        match list with 
        |[]-> ListAfter @ ListBefMin
        |h::tail ->
            let newIndEl = indEl+1
            if indEl<indMin then 
                let NewList = ListBefMin @ [h]
                beforemin tail indMin newIndEl NewList ListAfter
            else 
                let NewList = ListAfter @ [list.Head]
                beforemin tail indMin newIndEl ListBefMin NewList
    beforemin list indexMin 0 [] []
    

[<EntryPoint>]
let main argv =
    Console.WriteLine("Новый получившийся список:")
    readData |> BeforeMin|>writeList
    0 