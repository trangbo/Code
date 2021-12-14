// Echo2 prints its command-line arguments
package main

import (
	"fmt"
	"os"
	"time"
	"strings"
)

func main() {
	start := time.Now();
	fmt.Println(strings.Join(os.Args[1:], " "))
	fmt.Println(time.Since(start))
}
