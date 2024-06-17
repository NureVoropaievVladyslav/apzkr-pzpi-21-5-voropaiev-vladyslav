import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Pond } from '../models/pond';

@Injectable({
  providedIn: 'root'
})
export class PondsService {

  constructor(private http: HttpService) { }

  get() {
    return this.http.get<Pond[]>('ponds');
  }

  export() {
    return this.http.get<string>('ponds/export');
  }

  import(jsonContent: string) {
    return this.http.post('ponds/import', { jsonContent: jsonContent });
  }

  delete(id: string) {
    return this.http.delete(`ponds?pondId=${id}`);
  }
}
