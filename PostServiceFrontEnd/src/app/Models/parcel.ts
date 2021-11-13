import { ParcelMachine } from './parcelMachine';

export interface Parcel {
  id?: number;
  receiverFullName: string;
  weight: string;
  phone: string;
  description: string;
  parcelMachineId: string;
  parcelMachine?: ParcelMachine;
}
