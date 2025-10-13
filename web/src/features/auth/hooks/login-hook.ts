import { useMutation } from "@tanstack/react-query";
import { apiClient } from "@/api/client";
import { RequestError } from "@/types";

export interface LoginFormData {
  username: string;
  password: string;
}

interface LoginResponse {
  dataToken?: any;
}

// API call using apiClient
const loginApi = async (data: LoginFormData): Promise<LoginResponse> => {
  try {
    const response = await apiClient.apiAuthLoginPost({
      username: data.username,
      password: data.password,
    });

    // Assuming the API returns a successful response with token in results
    return {
      dataToken: response.data.results, // Adjust based on your actual response structure
    };
  } catch (error: any) {
    console.table(error);
    const errorData: RequestError = error;
    if (errorData?.type === "ValidationError" && errorData.invalidParams) {
      throw new Error("", { cause: errorData });
    } else {
      throw new Error(errorData.ErrorDetail || "Đăng nhập thất bại", {
        cause: errorData,
      });
    }
  }
};

export const useLogin = () => {
  return useMutation({
    mutationFn: loginApi,
  });
};
