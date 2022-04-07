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

//Дан целочисленный массив. Найти количество чётных элементов.

let CountEvent list = List.length(List.filter(fun x -> x%2=0)list)
     
[<EntryPoint>]
let main argv =
   Console.WriteLine("Количество чётных элементов:")
   readData|> CountEvent |> Console.WriteLine;
    0 