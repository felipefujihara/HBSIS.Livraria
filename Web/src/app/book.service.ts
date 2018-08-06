import { Injectable } from '@angular/core';
import { Http, Response, Headers, URLSearchParams, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

import { Book, ResponseResult } from './models';

@Injectable()
export class BookService {
  //URL for CRUD operations
  baseUrl = environment.apiUrl;
  apiUrl = this.baseUrl + "api/books";
  
  //Create constructor to get Http instance
  constructor(private http: HttpClient) { 
  }
  //Fetch all Books
  getBooks(): Observable<Book[]> {
    var teste = this.http.get<Book[]>(this.apiUrl)
    return teste;
  }
  //Create Book
  createBook(Book: Book): Observable<any> {
    return this.http.post(this.apiUrl, Book, {observe: 'response'})
           .pipe(map(success => success.status))
  }
  //Fetch Book by id
  getBookById(pid: number): Observable<Book> {
    return this.http.get<Book>(this.apiUrl + "/" + pid)
  }	
  //Update Book
  updateBook(Book: Book): Observable<any> {
    return this.http.put(this.apiUrl + "/" + Book.id, Book, {observe: 'response'})
           .pipe(map(success => success.status))
  }
  //Delete Book	
  deleteBookById(pid: number): Observable<any> {
    return this.http.delete(this.apiUrl +"/"+ pid, {observe: 'response'})
           .pipe(map(success => success.status))
  }
}
