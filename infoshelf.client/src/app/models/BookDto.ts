export class BookDto {
  constructor(
    public id: number = 0,
    public titulo: string = "",
    public autor: string = "",
    public genero: string = "",
    public ano: number = 0
  ) { }
}