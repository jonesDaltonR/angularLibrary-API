import { Injectable } from '@angular/core';
import { Book } from './models/book';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private _url = 'http://localhost:64434/api/book';

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this._url);
  }
  searchBooks(query : string)
  {
    return this.http.get<Book[]>(this._url + "?query="+encodeURIComponent(query));
  }
}
