import { useState } from "react";

export type ColumnsMeta = {
    columns: number,
    minColumns: number;
    maxColumns: number;
    setColumnCount: (count: number) => void;
}

/**
 * Hook for managing the number of columns in the clothing gallery on the closet page.
 */
const useColumns = (defaultColumns: number, min: number, max: number): ColumnsMeta => {
    const [ columns, setColumns ] = useState<number>(() => {
        const saved = localStorage.getItem("columns");
        return saved ? parseInt(saved) : defaultColumns;
    });

    const setColumnCount = (count: number) => {
        if (count < min || count > max) return;
        localStorage.setItem("columns", count.toString())
        setColumns(count);
    }

    return { columns, minColumns: min, maxColumns: max, setColumnCount}
};

export default useColumns;