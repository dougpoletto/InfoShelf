export class BookDto {
  public id: number = 0;
  public titulo: string = "";
  public autor: string = "";
  public genero: string = "";
  public ano: number = 0;
  constructor(data?: Partial<BookDto>) {
    Object.assign(this, data);
  }
}