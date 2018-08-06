import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { BookService } from '../Book.service';

@Component({
  selector: 'app-Bookadd',
  templateUrl: './Bookadd.component.html',
  styleUrls: ['./Bookadd.component.css']
})
export class BookaddComponent implements OnInit {
  statusCode: number;
  errmsg: string;
  filename: string;
  id;

  //Create form
  BookForm = new FormGroup({
    id: new FormControl(""),
    name: new FormControl("", Validators.compose([
        Validators.required,
        Validators.minLength(5)
    ])),
    category: new FormControl("", Validators.compose([
      Validators.required,
      Validators.minLength(5)
    ])),
  });

  constructor(private service: BookService, private router: Router, private route: ActivatedRoute) { }
  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    if (this.id != null) {
      this.service.getBookById(this.id).subscribe(Book => {
        this.BookForm.setValue({ id: Book.id, name: Book.name, category: Book.category});  
      },
      error => {this.statusCode = error.statusCode; this.errmsg = error.message});   
    }
  }
  onClickSubmit() {
    if (this.BookForm.invalid) {
      return; 
    }   
    let Book = this.BookForm.value;
    console.log(Book);
    if (Book.id == null || Book.id == "") {  
      Book.id = 0;
      this.service.createBook(Book).subscribe(successCode => {
          this.statusCode = successCode;
          this.router.navigate(['Booklist'])
        },
        error => {this.statusCode = error.statusCode; this.errmsg = error.message});
    } else {  
      this.service.updateBook(Book).subscribe(successCode => {
          this.statusCode = successCode;
          this.router.navigate(['Booklist'])
        },
        error => {this.statusCode = error.statusCode; this.errmsg = error.message});
    }
  }
}