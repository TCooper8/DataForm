namespace DataForm

open System

module Form =
  type FormFieldType =
    | FormStringField
    | FormNumberField
    | FormSecretField

  type FormFieldValue =
    | FormFieldString of string
    | FormFieldNumber of float

  type FormField = FormFieldType * string

  type FormRecord = {
    id: Guid
    name: string
    fields: FormField seq
    rows: FormFieldValue seq seq
  }