export interface User {
  id: number | null;
  firstName: string | null;
  lastName: string | null;
  email: string | null;
  token: string | null;
}

export const UserInitialState: User = {
  id: 0,
  firstName: "",
  lastName: "",
  email: "",
  token: "",
};
