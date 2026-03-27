import { createContext, useContext, type ReactNode } from "react";
import { useClothingItems, type UseGetClothingItemsReturn } from "../../clothing/hooks/useClothing";

const ClosetContext = createContext<UseGetClothingItemsReturn | null>(null);

type ContextProps = {
    children: ReactNode;
}

export const ClosetProvider = ({ children }: ContextProps) => {
    const getClothing = useClothingItems();
    
    return (
        <ClosetContext.Provider value={getClothing}>
            {children}
        </ClosetContext.Provider>
    )
}

export const useClosetContext = () => {
    const context = useContext(ClosetContext);

    if (!context) {
        throw new Error("useClosetContext must be used within a ClosetProvider")
    }

    return context;
}