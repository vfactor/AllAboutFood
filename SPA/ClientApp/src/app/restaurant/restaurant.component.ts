import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html'
})

export class RestaurantComponent {
  public restaurants: Restaurant[];

  constructor(http: HttpClient, @Inject('API_BASE_URL') baseUrl: string) {
    http.get<Restaurant[]>(baseUrl + '/api/Restaurant').subscribe(result => {
      this.restaurants = result;
    }, error => console.error(error));
  }
}

interface Restaurant {
  Id: number;
  Name: string;
}
