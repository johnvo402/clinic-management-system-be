"use client";

import type React from "react";
import { useState, useCallback } from "react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { LoginFormData, useLogin } from "../hooks/login-hook";
import { useAuth } from "@/hooks/use-auth";

export function LoginForm() {
  const [formData, setFormData] = useState<LoginFormData>({
    username: "",
    password: "",
  });
  const [errors, setErrors] = useState<
    Partial<Record<keyof LoginFormData, string>>
  >({});

  const {
    mutate: loginMutation,
    isPending: isLoading,
    error: loginError,
  } = useLogin();
  const { login } = useAuth();

  const handleSubmit = useCallback(
    (e: React.FormEvent) => {
      e.preventDefault();
      setErrors({});

      loginMutation(formData, {
        onSuccess: (data) => {
          login(data.dataToken || null);
        },
        onError: (error: any) => {
          // Handle API error
          if (
            error.cause?.type === "ValidationError" &&
            error.cause.invalidParams
          ) {
            const fieldErrors: Partial<Record<keyof LoginFormData, string>> =
              {};
            error.cause.invalidParams.forEach((param: any) => {
              const fieldName =
                param.propertyName.toLowerCase() as keyof LoginFormData;
              fieldErrors[fieldName] = param.reasons?.[0]?.message;
            });
            setErrors(fieldErrors);
          }
        },
      });
    },
    [formData, loginMutation, login]
  );

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
    // Clear error for the field being edited
    setErrors((prev) => ({ ...prev, [name]: undefined }));
  };

  return (
    <Card className="w-full max-w-md">
      <CardHeader className="space-y-1">
        <CardTitle className="text-2xl font-bold">Đăng Nhập</CardTitle>
        <CardDescription>
          Nhập tên đăng nhập và mật khẩu để truy cập tài khoản của bạn
        </CardDescription>
      </CardHeader>
      <CardContent>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="username">Tên đăng nhập</Label>
            <Input
              id="username"
              name="username"
              type="text"
              placeholder="Nhập tên đăng nhập"
              value={formData.username}
              onChange={handleInputChange}
              required
              disabled={isLoading}
            />
            {errors.username && (
              <p className="text-sm text-red-500">{errors.username}</p>
            )}
          </div>
          <div className="space-y-2">
            <Label htmlFor="password">Mật khẩu</Label>
            <Input
              id="password"
              name="password"
              type="password"
              placeholder="Nhập mật khẩu"
              value={formData.password}
              onChange={handleInputChange}
              required
              disabled={isLoading}
            />
            {errors.password && (
              <p className="text-sm text-red-500">{errors.password}</p>
            )}
          </div>
          {loginError && !errors.username && !errors.password && (
            <p className="text-sm text-red-500">{loginError.message}</p>
          )}
          <Button type="submit" className="w-full" disabled={isLoading}>
            {isLoading ? "Đang đăng nhập..." : "Đăng Nhập"}
          </Button>
        </form>
      </CardContent>
    </Card>
  );
}
