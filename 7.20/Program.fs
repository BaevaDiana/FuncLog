open System

//ввод нескольких строк
let readStrings n = 
   let rec readstrings n list = 
       match n with 
       |0-> list 
       |_->
           let newList = list @ [Console.ReadLine()]
           readstrings(n-1) newList
   readstrings n []

//вывод списка    
let rec writeList list = 
    List.iter(fun x->printfn "%O" x) list


//1. Отсортировать списки в порядке увеличения разницы между средним количеством согласных и средним количеством гласных букв в строке

//подсчёт количества гласных и согласных букв в строке соответственно и вычисление разницы
let SortByLetters str = 
    let AveradeNumbersOfVowels=Convert.ToSingle(String.length(String. filter (fun x -> x='а' ||x='о'||x='э'|| x='е'||x='и'||x='ы'||x='у'||x='ё'||x='ю'||x='я') str))/ Convert.ToSingle(String.length str)
    let AveradeNumbersOfСonsonants=Convert.ToSingle(String.length (String. filter (fun x -> not(x='а' ||x='о'||x='э'||x='е'||x='и'||x='ы'||x='у'||x='ё'||x='ю'||x='я')) str)) / Convert.ToSingle(String.length str)
    Math.Abs(AveradeNumbersOfСonsonants-AveradeNumbersOfVowels)
//сортировка списка строк
let SortList liststr =  List.sortBy (fun x->SortByLetters x) liststr


//6.Отсортировать строки в порядке увеличения медианного значения выборки строк
//(прошлое медианное значение удаляется из выборки и производится поиск нового медианного значения)

//поиск медианы
let FindOfMedian list = 
     List.item ((List.length list)/2) (List.sort list)

let removeAt index list =
    list |> List.indexed |> List.filter (fun (i, _) -> i <> index) |> List.map snd

//cортировка
let SortByMedian list = 
    let rec sortbymedian list sortList =
        match list with
        |[]->sortList
        |_ ->
            let nowMed = FindOfMedian list //ищем медиану в текущей строке
            let indMed =List.findIndex (fun x->x=nowMed) list //ищем по индексу медиану в строке
            let newList = removeAt (indMed) list//удаляем прошлое медианное значение
            sortbymedian newList (sortList @ [nowMed])
    sortbymedian list []
            


let FunctionSelection  = function
    |1 -> SortList 
    |2 -> SortByMedian 

 
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество строк,затем сами строки: ")
    let strs = Console.ReadLine() |> Convert.ToInt32 |> readStrings 
    Console.WriteLine("Введите номер функции:
     1 - cортировка по количеству согласных и гласных букв в строке
     2 - cортировка по медианному значению
     ")
    let n = Console.ReadLine() |> Convert.ToInt32 |> FunctionSelection
    strs |> n |>writeList
    0 