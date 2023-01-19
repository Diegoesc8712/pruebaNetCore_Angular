import { TestBed } from '@angular/core/testing';
import { ProductoService } from './productos-list.service';


describe('ProductosListService', () => {
  let service: ProductoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
