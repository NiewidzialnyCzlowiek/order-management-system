import { DataService } from './data.service';
import { Customer } from './interfaces/customer.interface';
import { asyncData, asyncError } from '../testing/async-observable-helpers';

const generateCustomers = () => [
  { no: 'cust001', name: 'customer name 1', addresses: null},
  { no: 'cust002', name: 'customer name 2', addresses: null},
  { no: 'cust003', name: 'customer name 3', addresses: null},
  { no: 'cust004', name: 'customer name 4', addresses: null}
] as Customer[];

describe('[WHEN] getCustomers', () => {
  let httpClientSpy: { get: jasmine.Spy };
  let dataService: DataService;

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
    dataService = new DataService(<any> httpClientSpy);
  });

  it('should get predefined customers', () => {
    const expectedCustomers = generateCustomers();
    httpClientSpy.get.and.returnValues(asyncData(expectedCustomers));

    dataService.getCustomers().subscribe(
      customers => expect(customers).toEqual(expectedCustomers, 'Expected predefined customers'),
      fail
    );
    expect(httpClientSpy.get.calls.count()).toBe(1, 'There should be only one call');
  });
});
