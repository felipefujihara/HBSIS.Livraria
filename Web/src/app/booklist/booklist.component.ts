import { Component, OnInit } from '@angular/core';
import { BookService } from '../Book.service';

@Component({
  selector: 'app-Booklist',
  templateUrl: './Booklist.component.html',
  styleUrls: ['./Booklist.component.css']
})
export class BooklistComponent implements OnInit {

  constructor(private service: BookService) { }
  Books;
  statusCode: number;
  errmsg: string;

  ngOnInit() {
    this.getBooks();
  }
  //Fetch all Books
  getBooks() {
    this.service.getBooks().subscribe(
      data => this.Books = data,
      error => { 
        debugger;
        this.statusCode = error.statusCode; this.errmsg = error.message});   
    }

  deleteBook(event) { 
    if(window.confirm('Are you sure to delete this Book?')){
      this.service.deleteBookById(event.id).subscribe(successCode => {
        this.statusCode = successCode;
        this.getBooks();	
      },
      error => {this.statusCode = error.statusCode; this.errmsg = error.message});
    }
  }
}
