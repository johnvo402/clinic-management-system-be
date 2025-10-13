import { create } from "zustand";
import { persist } from "zustand/middleware";

export interface Credentials {
  refreshToken: string | null | undefined;
  accessToken: string | null | undefined;
  expiresIn: number | null | undefined;
}

export interface AuthState {
  credentials: Credentials | null;
  user: any | null;
  isAuthenticated: boolean;
  // Actions
  login: (credentials: Credentials | null) => void;
  logout: () => void;
  updateUser: (user: any) => void;
}

export const useAuth = create<AuthState>()(
  persist(
    (set) => ({
      credentials: null,
      user: null,
      isAuthenticated: false,
      branchActive: null,

      login: (credentials: Credentials | null) =>
        set(() => ({
          credentials,
          isAuthenticated: true,
        })),

      logout: () =>
        set(() => ({
          credentials: null,
          isAuthenticated: false,
          user: null,
          branchActiveId: null,
        })),

      updateUser: (newUserData: any) =>
        set((state) => ({
          ...state,
          user: state.user ? { ...state.user, ...newUserData } : newUserData,
        })),
    }),
    { name: "auth-storage" }
  )
);
