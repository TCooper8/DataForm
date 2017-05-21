namespace DataForm 

module Html =
  type AttributeDesc = string * string

  type ElemDesc =
    | Div of AttributeDesc seq * ElemDesc seq
    | Text of string

  let div attributes children = Div (attributes, children)

  let text content = Text content