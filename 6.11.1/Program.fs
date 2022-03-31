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

//проверка длины
let BuildList list = 
    if List.length list % 3=0 then list
    else 
        if List.length list % 3=1 then list @ [1] @ [1]
        else list @ [1]

// создания списка,удовлетворяющего условию
let Sum f list =
    let rec sum list f newList = 
        match list with
        |[]->newList
        |h::tail->
            let h2 = tail.Head
            let h3 = tail.Tail.Head 
            let resSum = f h h2 h3
            let NextList = newList @ [resSum]
            sum tail.Tail.Tail f NextList
    sum list f []

[<EntryPoint>]
let main argv =
    let l = readData
    Console.WriteLine("Новый список: ")
    BuildList l|> Sum (fun x y z-> x+y+z) |> writeList
    0