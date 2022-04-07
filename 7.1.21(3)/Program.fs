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

//Дан целочисленный массив. Необходимо найти элементы,расположенные после первого максимального.

let ListAfterMax list =      
    let indFstMax = List.findIndex(fun x-> x=List.max list) list //ищем индекс первого максимального
    let ListAfterMax = list.[indFstMax+1..]
    ListAfterMax


[<EntryPoint>]
let main argv =
   Console.WriteLine("Элементы после первого максимального:")
   readData|> ListAfterMax |>writeList;
    0 