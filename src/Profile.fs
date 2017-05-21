namespace DataForm

open System
open DataForm.Form
open Fable.Import.Browser

module Profile =
  type State = {
    forms: FormRecord seq
  }

  let init (body:HTMLElement) =
    let profile =
      { forms =
          [ { id = Guid.NewGuid()
              name = "TestForm"
              fields =
                [ FormNumberField, "Sepal length"
                  FormNumberField, "Sepal width"
                  FormNumberField, "Petal length"
                  FormNumberField, "Petal width"
                  FormStringField, "Species"
                ]
              rows =
                [ [ FormFieldNumber 5.1
                    FormFieldNumber 3.5
                    FormFieldNumber 1.4
                    FormFieldNumber 0.2
                    FormFieldString "setosa"
                  ]
                  [ FormFieldNumber 4.9
                    FormFieldNumber 3.0
                    FormFieldNumber 1.4
                    FormFieldNumber 0.2 
                    FormFieldString "setosa"
                  ]
                ]
            }
            { id = Guid.NewGuid()
              name = "TestForm2"
              fields =
                [ FormStringField, "Churn"
                  FormStringField, "EmployeeAge"
                  FormNumberField, "Month"
                  FormNumberField, "Month"
                ]
              rows = []
            }
          ]
      }
    printfn "Loaded profile"

    let formList = document.getElementById "forms"

    for formRecord in profile.forms do
      let card = document.createElement "div"
      let cardContent = document.createElement "div"
      let table = document.createElement "table"
      let head = document.createElement "thead"
      let tbody = document.createElement "tbody"
      let tr = document.createElement "tr"

      tbody.appendChild tr |> ignore

      card.className <- "card-panel blue-grey darken-1"
      cardContent.className <- "card-content s12 m6 white-text"
      table.className <- "responsive-table"

      for fieldType, fieldName in formRecord.fields do
        let fieldType =
          match fieldType with
          | FormStringField -> "String"
          | FormNumberField -> "Number"
          | FormSecretField -> "Secret"
        // For each field, create a table header.
        let th = document.createElement "th"
        let td = document.createElement "td"

        th.textContent <- fieldName
        td.textContent <- fieldType

        head.appendChild th |> ignore
        tr.appendChild td |> ignore

      for row in formRecord.rows do
        let tr = document.createElement "tr"
        for value in row do
          let td = document.createElement "td"
          td.textContent <-
            match value with
            | FormFieldString str -> str
            | FormFieldNumber f -> string f
          tr.appendChild td |> ignore

        tbody.appendChild tr |> ignore

      table.appendChild head |> ignore
      table.appendChild tbody |> ignore
      cardContent.appendChild table |> ignore
      card.appendChild cardContent |> ignore
      body.appendChild card |> ignore
      printfn "Added forms"