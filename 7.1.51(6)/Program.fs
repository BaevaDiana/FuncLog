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

//Построить два списка L1 и L2, 
//где элементы L1 это неповторяющиеся элементы исходного списка,
//а элемент списка L2 с номером i показывает, сколько раз элемент списка L1 с таким номером повторяется в исходном.

let BuildList list = 
  List.fold (
        fun m x -> 
            let f = fst(m) @ [fst(x)]
            let s = snd(m) @ [snd(x)]
            (f,s))
        ([], [])(List.countBy (fun x->x) list)
    

[<EntryPoint>]
let main argv =
    let newList = readData|> BuildList 
    Console.WriteLine("Список L1:")
    writeList (fst(newList))
    Console.WriteLine("Список L2:")
    writeList (snd(newList))
    
    0 