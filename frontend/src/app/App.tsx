import { BreakpointProvider } from "../shared/context/BreakPointContext"
import AppRoutes from "./routes/AppRoutes"

function App() {
    return (
        <BreakpointProvider>
            <AppRoutes />
        </BreakpointProvider>
    )
}

export default App
