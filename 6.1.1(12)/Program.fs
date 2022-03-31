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

// Найти кол-во элементов, расположенных после последнего максимального


//поиск последнего максимального элемента
let IndexMaxEl list = 
    let rec IndMax listt max indM indEL=
        match list with
        |[]->indM
        |h::tail -> 
            let newMax = if h>=max then h else max
            let newInd = if h>=max then indEL else indM
            IndMax tail newMax newInd (indEL+1)
    IndMax list list.Head 0 0 

//длина списка
let ListLenght list = 
    let rec listlenght list count =
        match list with 
        |[]->count
        |h::tail->
            let newCount = count+1
            listlenght tail newCount
    listlenght list 0

//количество элементов после последнего максимального
let Count list = 
    let indexMax = IndexMaxEl list 
    let result = ListLenght list-indexMax-1
    result


[<EntryPoint>]
let main argv =
    readData|>Count|>Console.WriteLine
    0
