export interface Item {
  id: number | undefined,
  name: String,
  unit: String,
  expDate?: Date,
  categoryId: number,
  locationId: number
}
