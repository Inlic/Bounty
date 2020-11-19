import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-deputies',
  templateUrl: './deputies.component.html'
})
export class DeputiesComponent {
  public deputies: Deputy[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Deputy[]>(baseUrl + 'api/deputies').subscribe(result => {
      this.deputies = result;
    }, error => console.error(error));
  }
}

interface Deputy {
  name: string;
}
