import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom, Observable } from "rxjs";
import { BookDto } from "../models/BookDto";

@Injectable({ providedIn: "root" })
export class BookService {
  private readonly baseUrl = "https://localhost:7020/api/books";
  private readonly header = new HttpHeaders({
    'Custom-Header': 'valor-do-header'
  });
  constructor(private httpClient: HttpClient) { }

  async getListBooks(): Promise<any> {
    return await firstValueFrom(this.httpClient.get(`${this.baseUrl}/getListBooks`));
  }

  async postBook(data: BookDto): Promise<any> {
    return await firstValueFrom(this.httpClient.post(`${this.baseUrl}/createBook`, data));
  }
}