#r "../node_modules/fable-core/Fable.Core.dll"

#load "Form.fs"
#load "Html.fs"
#load "Profile.fs"
#load "Main.fs"

open Fable.Core
open Fable.Import.Browser

open DataForm

[<Interface>]
type MaterialSelect = 
  abstract material_select: unit -> unit

module Web =
  let profileBody = document.getElementById "profile"
  if profileBody <> null then
    Profile.init profileBody

  let formBuilder = document.getElementById "form-builder" :?> HTMLFormElement
  let formBuilderFields = document.getElementById "form-builder-fields" :?> HTMLLIElement

  let addFieldForm = document.getElementById "add-field" :?> HTMLButtonElement
  let addFieldButton = document.getElementById "add-field-submit" :?> HTMLButtonElement

  addFieldButton.addEventListener_click(fun mouseEvent ->
    let fieldNameInput = (addFieldForm.getElementsByTagName "input").Item 0
    let fieldName = (fieldNameInput :?> HTMLInputElement).value.Trim()

    if fieldName = "" then
      failwith "FieldName cannot be an empty value"

    let fieldTypeSelect = (addFieldForm.getElementsByTagName "select").Item 0
    let fieldType = (fieldTypeSelect :?> HTMLSelectElement).value

    let field =
      let elem = document.createElement "li"
      let body = document.createElement "div"
      body.className <- "row"

      let fieldNameLabel = document.createElement "label"

      fieldNameLabel.textContent <- fieldName
      fieldNameLabel.setAttribute("for", fieldName)

      let fieldNameElem = document.createElement ("input")
      fieldNameElem.setAttribute("placeholder", fieldName)
      fieldNameElem.setAttribute("type", fieldType)
      fieldNameElem.setAttribute("name", fieldName)

      body.appendChild fieldNameLabel |> ignore
      body.appendChild fieldNameElem |> ignore

      elem.appendChild body |> ignore
      elem
    formBuilderFields.appendChild field |> ignore


    () :> obj
  )