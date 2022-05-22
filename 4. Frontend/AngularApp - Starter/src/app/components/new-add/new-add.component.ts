import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-add',
  templateUrl: './new-add.component.html',
  styleUrls: ['./new-add.component.scss']
})
export class NewAddComponent implements OnInit {

  categories: any[] = [];
  errorMsg = '';
  model = {
    kategoriaId: 0,
    hirdetesDatuma: new Date().toISOString().substring(0, 10),
    leiras: '',
    tehermentes: true,
    kepUrl: ''
  }
  constructor(
    private http: HttpClient,
    private router: Router) { }

  ngOnInit(): void {
    this.http.get<any[]>('http://localhost:5000/api/kategoriak').subscribe(
      (data) => this.categories = data,
      (error) => console.log(error)
    );
  }

  send() {
    this.model.kategoriaId = Number(this.model.kategoriaId)
    this.http.post('http://localhost:5000/api/ujingatlan', this.model).subscribe(
      (data) => this.router.navigate(['/offers']),
      (error) => this.errorMsg = error.message
    )
  }

}
