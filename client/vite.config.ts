import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig(({mode})=>{
  const env = loadEnv(mode, process.cwd(), "");
  return {
    plugins: [react()],
    server: {
      proxy: {
        "/api": {
          target: env.API_URL || "https://localhost:7200",
          changeOrigin: true,
          rewrite: (path) => path.replace(/^\/api/, ""),
          secure: false
        }
      }
    }
  }
})
